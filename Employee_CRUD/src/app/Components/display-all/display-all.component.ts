import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../Services/employee.service';
import { IEmployee } from '../../Models/iemployee';

@Component({
  selector: 'app-display-all',
  templateUrl: './display-all.component.html',
  styleUrl: './display-all.component.scss'
})
export class DisplayAllComponent implements OnInit {

  pageSize: number = 4; // Number of items per page
  currentPage: number = 1; // Current page number
  totalItems: number = 0; // Total number of items (to be set after fetching data)

  employees: IEmployee[] = [];
  
  constructor(private _EmployeeService:EmployeeService ) {}

  ngOnInit(): void {
    this.getAllEmployees();
    this.getSomeEmployees(1,4)
  }
  

  getAllEmployees(){
    this._EmployeeService.getAllEmployees().subscribe((response) => {
      this.totalItems = response.length; // Set total items after fetching all employees
    });
  }


  getSomeEmployees(pageNum : number = 1 , pageSize:number = 4){
    this._EmployeeService.getSomeEmployees(pageNum , pageSize).subscribe((response) => {
      this.employees = response;
    });
  }

  searchForEmployee(searchTerm: string) {
    if (searchTerm) {
      this._EmployeeService.SearchForEmployee(searchTerm).subscribe((response) => {
        this.employees = response;
        this.totalItems = response.length; 
      });
    }else{
      this.getAllEmployees(); // Reset to all employees if search term is empty
      this.getSomeEmployees(this.currentPage, this.pageSize);
    }
  }


  pageChanged(event: number) {
    this.currentPage = event;   
    this.getSomeEmployees(this.currentPage, this.pageSize);
   }
    
}
