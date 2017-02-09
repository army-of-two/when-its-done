using System.Collections.Generic;
using WhenItsDone.DTOs.WorkerVIewsDTOs;

namespace WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP
{
    public class APWorkersControlViewModel
    {
        public IEnumerable<WorkerNamesIdDTO> WorkersWithDishes { get; set; }
    }
}
