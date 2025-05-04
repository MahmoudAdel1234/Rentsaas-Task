import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../Services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IEmployee } from '../../Models/iemployee';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.scss'
})
export class EditComponent implements OnInit {

  employee : IEmployee = {} as IEmployee;

  EditEmployee = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    position: new FormControl(''),
  })

  constructor(private _EmployeeService : EmployeeService , private _ActivtedRoute : ActivatedRoute , private toastr: ToastrService  , private _Router : Router) { }

  ngOnInit(): void {

    this._ActivtedRoute.params.subscribe((params) => {
      const id = params['empId'];
      this.getEmployeeById(id);
    });

  }

  getEmployeeById(id:number){
    this._EmployeeService.getEmployeeById(id).subscribe((response) => {
      this.employee = response;
    });
  }

  

  onSubmit(formData : FormGroup) {

  if(formData.value.firstName === '' ){
      formData.value.firstName = this.employee.firstName; 
  }
  if(formData.value.lastName === '' ){
      formData.value.lastName = this.employee.lastName; 
  }
  if(formData.value.email === '' ){
      formData.value.email = this.employee.email; 
  }
  if(formData.value.position === '' ){
      formData.value.position = this.employee.position; 
  }



  this._EmployeeService.UpdateEmployee(this.employee.id , formData.value).subscribe(() => {
    this.toastr.success('Employee Updated Successfully');
    this.EditEmployee.reset(); // Reset the form after successful submission
    this._Router.navigate(['/display-all']);
  });


}


}