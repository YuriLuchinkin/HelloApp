using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class ExchangeModel : PageModel
    {
        public string Message { get; set; }
        private readonly decimal currentRate = 64.1m;
        public void OnGet()
        {
            Message = "������� �����";
        }
        public void OnPost(int? sum)
        {
            if (sum == null || sum < 1000)
            {
                Message = "�������� ������������ �����. ��������� ����";
            }
            else
            {
                decimal result = sum.Value / currentRate;
                // ToString("F2") - �������������� �����: F2 - ������� ����� � 2 ������� ����� �������
                Message = $"��� ������ {sum} ������ �� �������� {result.ToString("F2")}$.";
            }
        }
    }
}