using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.CreatePages
{
    public class CreatePresenter : Presenter<ICreateView>, ICreatePresenter
    {
        private readonly IDishesAsyncService dishesAsyncService;

        public CreatePresenter(ICreateView view, IDishesAsyncService dishesAsyncService)
            : base(view)
        {
            Guard.WhenArgument(dishesAsyncService, nameof(IDishesAsyncService)).IsNull().Throw();

            this.dishesAsyncService = dishesAsyncService;

            this.View.CreateDish += this.OnCreateDish;
        }

        public void OnCreateDish(object sender, CreateEventArgs args)
        {
            Guard.WhenArgument(args, nameof(CreateEventArgs)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.Name, nameof(args.Name)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.Price, nameof(args.Price)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.Calories, nameof(args.Calories)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.Carbohydrates, nameof(args.Carbohydrates)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.Fats, nameof(args.Fats)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.Protein, nameof(args.Protein)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.VideoUrl, nameof(args.VideoUrl)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.PhotoUrl, nameof(args.PhotoUrl)).IsNullOrEmpty().Throw();

            this.View.Model.IsSuccessful = this.dishesAsyncService.CreateDish(args.LoggedUserUsername, args.Name, args.Price, args.Calories, args.Carbohydrates, args.Fats, args.Protein, args.VideoUrl, args.PhotoUrl);
        }
    }
}
