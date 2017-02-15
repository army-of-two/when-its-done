﻿using Bytes2you.Validation;

using WebFormsMvp;

namespace WhenItsDone.MVP.CreatePages
{
    public class CreatePresenter : Presenter<ICreateView>, ICreatePresenter
    {
        public CreatePresenter(ICreateView view)
            : base(view)
        {
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
            Guard.WhenArgument(args.Video, nameof(args.Video)).IsNullOrEmpty().Throw();


        }
    }
}
