import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DisplayAllComponent } from './Components/display-all/display-all.component';
import { EditComponent } from './Components/edit/edit.component';
import { AddComponent } from './Components/add/add.component';
import { EmpolyeeComponent } from './Components/empolyee/empolyee.component';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { loaderInterceptor } from './Interceptors/loader.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './Components/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    DisplayAllComponent,
    EditComponent,
    AddComponent,
    EmpolyeeComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({timeOut:1500 , positionClass: 'toast-top-right'})
  ],
  providers: [
    provideHttpClient( withInterceptors([loaderInterceptor]) )
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
