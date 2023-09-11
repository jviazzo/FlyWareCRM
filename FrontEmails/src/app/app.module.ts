import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './Components/login/login.component';
import { LayoutComponent } from './Components/layout/layout.component';
import { SharedModule } from './Reusable/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  bootstrap: [AppComponent],
  providers: [
    // ...
    { provide: ErrorHandler } // Agregar esta línea para mostrar errores detallados en la consola
  ]

})
export class AppModule { }

export class ErrorService implements ErrorHandler {
  handleError(error: any): void {
    console.error('Error:', error); // Muestra los errores en la consola del navegador
    // Puedes realizar otras acciones aquí, como enviar el error a un servicio de registro de errores.
  }
}
