using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Attributes;
using SocialNetwork.Domain.Queries.ExportData;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class ExportDataController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Contructor
        public ExportDataController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Export list users to excel file
        /// </summary>
        /// <returns></returns>
        [HttpGet("export-list-users")]
        [CustomAuthorize]
        public async Task<FileStreamResult> ExportListUsersToExcel()
        {
            var query = new ExportListUserQuery();
            var stream = await _mediator.Send(query);
            var ContentType = "application/msexcel";    //Defining the ContentType for excel file.
            var fileName = "ListUsers.xlsx";    //Define the file name.
            var content = stream.ToArray();

            Response.Clear();
            Response.Headers.Add("content-disposition", "attachment;filename=ListUsers.xlsx");
            Response.ContentType = ContentType;
            await Response.Body.WriteAsync(content);
            Response.Body.Flush();

            return File(stream, ContentType, fileName);
        } 
        #endregion
    }
}
