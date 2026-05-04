var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add Session
builder.Services.AddSession();

var app = builder.Build();

// Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable Session
app.UseSession();

app.UseAuthorization();

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Dashboard}/{id?}"
);

// About Page
app.MapControllerRoute(
    name: "about",
    pattern: "About",
    defaults: new { controller = "Home", action = "About" }
);

// Contact Page
app.MapControllerRoute(
    name: "contact",
    pattern: "Contact",
    defaults: new { controller = "Home", action = "Contact" }
);

// Shop Page
app.MapControllerRoute(
    name: "shop",
    pattern: "Shop",
    defaults: new { controller = "Product", action = "Index" }
);

// Product Details
app.MapControllerRoute(
    name: "productdetails",
    pattern: "Product/{id}",
    defaults: new { controller = "Product", action = "Details" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();