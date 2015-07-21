using Customer.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class ReportController : Controller
    {
        private v_rpt1Repository rptRepository = RepositoryHelper.Getv_rpt1Repository();
        // GET: /Report/
        public ActionResult Index()
        {
            return View(this.rptRepository.All());
        }

        [HttpPost]
        public ActionResult ExportExcel()
        {
            var data = this.rptRepository.All();
            string path = Server.MapPath("~/Templates/客戶資訊.xlsx");
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            IWorkbook wb = new XSSFWorkbook(stream);
            stream.Close();
            ISheet sheet = wb.GetSheetAt(0);
            ICellStyle cs = sheet.GetRow(1).Cells[0].CellStyle;
            int Index = 1;
            foreach (var item in data)
            {
                IRow row = sheet.CreateRow(Index);
                CreateCell(item.客戶名稱, row, 0, cs);
                CreateCell(item.聯絡人數量.ToString(), row, 1, cs);
                CreateCell(item.客戶帳戶數量.ToString(), row, 2, cs);
                Index++;
            }
            string serverPath = @"D:/repot.xlsx";
            using (FileStream file = new FileStream(serverPath, FileMode.Create))
            {
                wb.Write(file);
                file.Close();
            }
            return File(serverPath, "application/excel","Report.xlsx");
        }

        private static void CreateCell(string value, IRow row, int index, ICellStyle cellStyle)
        {
            ICell cell = row.CreateCell(index);
            cell.SetCellValue(value);
            cell.CellStyle = cellStyle;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.rptRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
