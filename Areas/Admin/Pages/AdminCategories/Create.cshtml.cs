﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectThoiTrang.Models;

namespace ProjectThoiTrang.Areas.Admin.Pages.AdminCategories
{
    public class CreateModel : PageModel
    {
        private readonly WebFashionContext _context;
        private readonly INotyfService _notify;

        public CreateModel(WebFashionContext context, INotyfService notify)
        {
            _context = context;
            _notify = notify;
        }

        [BindProperty]
        public Category Category { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Add(Category);
            await _context.SaveChangesAsync();
            _notify.Success("Tạo mới thành công");
            return RedirectToPage("./Index");
        }
    }
}
