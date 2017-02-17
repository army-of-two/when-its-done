﻿using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.DetailsMVP
{
    public interface IDetailsView : IView<DetailsViewModel>
    {
        event EventHandler<DetailsGetDishDetailsEventArgs> OnGetDishDetails;
    }
}
