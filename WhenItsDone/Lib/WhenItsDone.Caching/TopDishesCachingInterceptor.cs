using System;
using System.Web;

using Bytes2you.Validation;

using Ninject.Extensions.Interception;

using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Caching
{
    public class TopDishesCachingInterceptor : IInterceptor
    {
        private const int CacheTimeOut = 5;
        private const string CacheItemName = "TopDishes";
        private const string MethodToInterceptName = "GetTopCountDishesByRating";

        private readonly IDishesAsyncRepository dishesAsyncRepository;

        private DateTime? lastUpdate;

        public TopDishesCachingInterceptor(IDishesAsyncRepository dishesAsyncRepository)
        {
            Guard.WhenArgument(dishesAsyncRepository, nameof(IDishesAsyncRepository)).IsNull().Throw();

            this.dishesAsyncRepository = dishesAsyncRepository;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name != TopDishesCachingInterceptor.MethodToInterceptName)
            {
                invocation.Proceed();
                return;
            }

            var timeElapsedSinceLastUpdate = (DateTime.UtcNow - (this.lastUpdate ?? DateTime.UtcNow)).Duration();
            var currentCachedContent = HttpContext.Current.Cache[TopDishesCachingInterceptor.CacheItemName];
            if (currentCachedContent != null && timeElapsedSinceLastUpdate.Minutes < TopDishesCachingInterceptor.CacheTimeOut)
            {
                invocation.ReturnValue = currentCachedContent;
                return;
            }
            else
            {
                var dishesCount = (int)invocation.Request.Arguments[0];
                var addSampleData = (bool)invocation.Request.Arguments[1];

                var updatedContent = this.dishesAsyncRepository.GetTopCountDishesByRating(dishesCount).Result;
                if (updatedContent.Count < dishesCount && addSampleData == true)
                {
                    updatedContent = this.dishesAsyncRepository.AddTopCountDishesSampleData(dishesCount, updatedContent);
                }

                this.lastUpdate = DateTime.UtcNow;
                HttpContext.Current.Cache[TopDishesCachingInterceptor.CacheItemName] = updatedContent;
                invocation.ReturnValue = updatedContent;
                return;
            }
        }
    }
}
