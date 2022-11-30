## Create Angular Project
```
    ng new EmployeeUI
```

## Install Material
```
    ng add @angular/material
```

## Create Interfaces
```
ng g i Interfaces/Department
ng g i Interfaces/Employee
ng g i Interfaces/ResponseApi
```

## Config API url
```
export const environment = {
  production: false,
  endpoint: "http://localhost:5017"
};
```

## Create Services
```
ng g s Services/Department
ng g s Services/Employee
ng g i Interfaces/ResponseApi
```