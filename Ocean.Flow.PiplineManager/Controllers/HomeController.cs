using Microsoft.AspNetCore.Mvc;
using Ocean.Service.PipelineManager;

namespace Ocean.Flow.PiplineManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly PipelineManagerService _pipelineManager;


        public HomeController(PipelineManagerService pipelineManager)
        {

            _pipelineManager = pipelineManager;
        }


        [HttpPost("Index")]
        public async Task<IActionResult> Index([FromBody] List<JobDefinition> jobs)
        {


            var lastJob = jobs.OrderBy(j => j.JobOrder).LastOrDefault();
            if (lastJob == null || lastJob.JobType != "ResponseService")
            {
                return BadRequest("Pipeline must end with an ResponseService.");
            }

            try
            {
                var result = await _pipelineManager.ExecutePipelineAsync(jobs, null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Hata durumlarını uygun şekilde ele al
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }
    }
}
