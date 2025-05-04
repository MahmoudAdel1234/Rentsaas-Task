import { EmployeeService } from './../../Services/employee.service';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IEmployee } from '../../Models/iemployee';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-empolyee',
  templateUrl: './empolyee.component.html',
  styleUrl: './empolyee.component.scss'
})
export class EmpolyeeComponent {

  constructor(private _EmployeeService : EmployeeService , private toastr: ToastrService , private _Router:Router ) { }

  @Input() employee: IEmployee = {} as IEmployee;
  @Output() employeeDeleted = new EventEmitter<void>();


  DeleteEmployee(id:number) {

    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor:  "#d33",
      cancelButtonColor: "#3085d6",
      confirmButtonText: "Yes, delete it!"
    }).then((result) => {
      
      if (result.isConfirmed) {

        Swal.fire({
          title: "Deleted!",
          text: "Employee Deleted Successfully",
          icon: "success"
        });

        this._EmployeeService.DeleteEmployee(id).subscribe( response => { 
          // this.toastr.success('Employee Deleted Successfully');
          this.employeeDeleted.emit(); // Notify parent to refresh data
    
        })

      }

    });
 } 

}



