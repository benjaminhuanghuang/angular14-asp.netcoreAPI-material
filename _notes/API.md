
## Create ASP.NET Core Web API project 

## Add dependencies 
Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools


## Entity Framework Database first
Run command at PackageManager Console, create models and dbcontext
```
    Scaffold-DbContext "server=BENTKPAD\SQLEXPRESS; DataBase=DBEmployee; Integrated Security=true; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models
```

Move Connection string to appsettings.json
```
    # appsettings.json

    "ConnectionStrings": {
        "sqlConnection": "server=localhost\\SQLEXPRESS;database=MyDb;Trusted_Connection=true;TrustServerCertificate=True"
    }
```

Inject MyDbContext in Program.cs
```
    # Program.cs
    builder.Services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));
```


## Create services

Inject services in Program.cs
```
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
```

## Auto Mapper
Add dependencies
```
    AutoMapper.Extensions.Microsoft.DependencyInjection
    AutoMapper
```

Create DTOs
 
Create Mapping Profile

Inject mapper into Program.cs
## 