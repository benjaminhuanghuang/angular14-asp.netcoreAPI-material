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

## Import modules
```
// Reactive forms
import {ReactiveFormsModule} from '@angular/forms';
// Http request
import {HttpClientModule} from '@angular/common/http';
// Material table
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
// Form control
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatButtonModule} from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
// Alert
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MatGridListModule} from '@angular/material/grid-list';

```


## Dependencies
```
npm i moment
npm i @angular/material-moment-adapter
```
```
import {MomentDateModule} from '@angular/material-moment-adapter';
```