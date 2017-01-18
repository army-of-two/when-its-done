using System;

using Ninject;

namespace WhenItsDone.WebFormsClient.App_Start
{

    /// <summary>
    /// Singleton implementation
    /// https://msdn.microsoft.com/en-us/library/ff650316.aspx
    /// 
    /// Singleton should not be required,
    /// Ninject kernel is guaranteed to be only 
    /// registered once, by Ninject itself. (?)
    /// </summary>
    public sealed class NinjectKernelInstanceProvider
    {
        private static volatile IKernel instance;
        private static object syncRoot = new Object();

        private NinjectKernelInstanceProvider()
        {

        }

        public static IKernel Instance
        {
            get
            {
                return NinjectKernelInstanceProvider.instance;
            }

            set
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            NinjectKernelInstanceProvider.instance = value;
                        }
                    }
                }
            }
        }
    }
}