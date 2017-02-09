﻿using System;
using System.Collections.Generic;
using WebFormsMvp;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP
{
    public class APWorkersControlPresenter : Presenter<IAPWorkersControlView>, IAPWorkersControlPresenter
    {
        private readonly IWorkersAsyncService workersService;

        public APWorkersControlPresenter(IAPWorkersControlView view, IWorkersAsyncService workersService)
            : base(view)
        {
            if (workersService == null)
            {
                throw new ArgumentNullException("WorkersService");
            }

            this.workersService = workersService;

            this.View.GetWorkersNamesAndId += View_GetWorkersNamesAndId;
        }

        private void View_GetWorkersNamesAndId(object sender, EventArgs e)
        {
            this.View.Model.WorkersWithDishes = this.workersService.GetWorkersWithDIshes();
        }
    }
}
