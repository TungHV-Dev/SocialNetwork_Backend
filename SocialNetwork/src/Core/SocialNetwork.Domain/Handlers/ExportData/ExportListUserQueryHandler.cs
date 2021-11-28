using ClosedXML.Excel;
using MediatR;
using SocialNetwork.Domain.Queries.ExportData;
using SocialNetwork.Repository.Interfaces;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.ExportData
{
    public class ExportListUserQueryHandler : IRequestHandler<ExportListUserQuery, MemoryStream>
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region Contructor
        public ExportListUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Public Functions
        public async Task<MemoryStream> Handle(ExportListUserQuery request, CancellationToken cancellationToken)
        {
            var users = (await _userRepository.GetAllUser()).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ListUsers");

                worksheet.Column("A").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column("C").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column("D").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column("E").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column("F").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column("G").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                var currentRow = 3;
                worksheet.Range("C1:E1").Merge();

                worksheet.Cell("C1").Value = "LIST USERS";
                worksheet.Cell("C1").Style.Font.FontSize = 25;
                worksheet.Cell("C1").Style.Font.Bold = true;
                worksheet.Range("C1").Style.Fill.BackgroundColor = XLColor.Yellow;
                worksheet.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Cell(currentRow, 1).Value = "ID";
                worksheet.Cell(currentRow, 2).Value = "FirstName";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "UserName";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "Role";
                worksheet.Cell(currentRow, 7).Value = "TotalPosts";

                worksheet.Range("A3:G3").Style.Fill.BackgroundColor = XLColor.GreenPigment;
                worksheet.Range("A3:G3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A3:G3").Style.Font.Bold = true;


                for (int i = 0; i < users.Count; i++)
                {
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = users[i].ID.ToString();
                        worksheet.Cell(currentRow, 2).Value = users[i].FirstName;
                        worksheet.Cell(currentRow, 3).Value = users[i].LastName;
                        worksheet.Cell(currentRow, 4).Value = users[i].UserName;
                        worksheet.Cell(currentRow, 5).Value = users[i].Email;
                        worksheet.Cell(currentRow, 6).Value = users[i].Role;
                        worksheet.Cell(currentRow, 7).Value = users[i].TotalPosts.ToString();

                    }
                }
                worksheet.Column("A").DataType = XLDataType.Text;
                worksheet.Column("B").DataType = XLDataType.Text;
                worksheet.Column("C").DataType = XLDataType.Text;
                worksheet.Column("D").DataType = XLDataType.Text;
                worksheet.Column("E").DataType = XLDataType.Text;
                worksheet.Column("F").DataType = XLDataType.Text;
                worksheet.Column("G").DataType = XLDataType.Text;

                worksheet.Column("A").AdjustToContents();
                worksheet.Column("B").AdjustToContents();
                worksheet.Column("C").AdjustToContents();
                worksheet.Column("D").AdjustToContents();
                worksheet.Column("E").AdjustToContents();
                worksheet.Column("F").AdjustToContents();
                worksheet.Column("G").AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);

                return stream;
            }
        }
        #endregion
    }
}
