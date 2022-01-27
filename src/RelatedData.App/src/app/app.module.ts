import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BASE_URL } from '@core';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: BASE_URL,
      useValue: 'https://localhost:5001/'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
