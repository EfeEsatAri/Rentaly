using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Concrete;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.EntityFramework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<ICarDal, EfCarDal>();

builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IBranchDal, EfBranchDal>();

builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IBrandDal, EfBrandDal>();

builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();

builder.Services.AddScoped<IStepService, StepManager>();
builder.Services.AddScoped<IStepDal, EfStepDal>();

builder.Services.AddScoped<ICarModelService, CarModelManager>();
builder.Services.AddScoped<ICarModelDal,EfCarModelDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();

builder.Services.AddScoped<IFeaturesService, FeaturesManager>();
builder.Services.AddScoped<IFeaturesDal, EfFeaturesDal>();

builder.Services.AddScoped<IFooterService, FooterManager>();
builder.Services.AddScoped<IFooterDal, EfFooterDal>();

builder.Services.AddScoped<IQuestionsService, QuestionsManager>();
builder.Services.AddScoped<IQuestionsDal, EfQuestionsDal>();

builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<IReservationDal, EfReservationDal>();

builder.Services.AddDbContext<RentalyContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseStatusCodePagesWithReExecute("/_404Page/Index/");
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
