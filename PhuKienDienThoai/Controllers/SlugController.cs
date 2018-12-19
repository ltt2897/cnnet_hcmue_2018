using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PhuKienDienThoai.Controllers
{
    public static class SlugController
    {
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.RemoveDiacritics().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }
    
        public static string RemoveDiacritics(this string text)
        {
            var s = new string(text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
    
            return s.Normalize(NormalizationForm.FormC);
        }

        public static int CalculateSaleOffPercent(int dongia, int giacu)
        {
            double t = (double) (giacu - dongia) / giacu * 100;

            return (int)Math.Ceiling(t);
        }
    }
}