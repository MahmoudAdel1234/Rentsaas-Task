import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EmployeeService } from '../../Services/employee.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrl: './add.component.scss'
})
export class AddComponent {

  AddEmployee = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    position: new FormControl(''),
  })

  constructor(private _EmployeeService:EmployeeService , private _Router : Router , private toastr: ToastrService) { }

 onSubmit(formData : FormGroup) {

      this._EmployeeService.AddEmployee(formData.value).subscribe(() => {
        
        this.toastr.success('Employee Added Successfully');
        this._Router.navigate(['/display-all']);
      });
    
 }



}




