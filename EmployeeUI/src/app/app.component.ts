import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Employee } from './Interfaces/employee';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeService } from './Services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ["FullName", "Department", "Salary", "HireDate", "Actions"];
  dataEmployee = new MatTableDataSource<Employee>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private _snackBar: MatSnackBar, private _employeeService: EmployeeService) {


  }

  applyFilter(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataEmployee.filter=filterValue.trim().toLowerCase();
  }

  showEmployees(){
    this._employeeService.getList().subscribe({
      next: (data) => {
        if(data.status){
          this.dataEmployee.data=data.value;
        }
      },
    });
  }

  ngOnInit(): void {
    this.showEmployees();
  }

  ngAfterViewInit(): void {
    this.dataEmployee.paginator = this.paginator;
  }
}
