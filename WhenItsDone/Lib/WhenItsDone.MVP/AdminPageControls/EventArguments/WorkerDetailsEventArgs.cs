using System;
using WhenItsDone.DTOs.WorkerVIewsDTOs;

namespace WhenItsDone.MVP.AdminPageControls.EventArguments
{
    public class WorkerDetailsEventArgs : EventArgs
    {
        public WorkerDetailsEventArgs(WorkerDetailInformationDTO workerDetails)
        {
            this.WorkerDetails = workerDetails;
        }

        public WorkerDetailInformationDTO WorkerDetails { get; set; }
    }
}
