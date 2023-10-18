import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatModule } from './modules/mat/mat.module';
import { BedComponent } from './componenets/bed/bed.component';
import { BedService } from './service/bed.service';
import { PreoperativeDiagnosisComponent } from './componenets/preoperative-diagnosis/preoperative-diagnosis.component';
import { SurgeryComponent } from './componenets/surgery/surgery.component';
import { WardCabinComponent } from './componenets/ward-cabin/ward-cabin.component';
import { PreoperativeDiagnosisService } from './service/preoperative-diagnosis.service';
import { SurgeryService } from './service/surgery.service';
import { WardCabinService } from './service/ward-cabin.service';

@NgModule({
  declarations: [
    AppComponent,
    BedComponent,
    PreoperativeDiagnosisComponent,
    SurgeryComponent,
    WardCabinComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HttpClientModule,
    MatModule
  ],
  providers: [
    BedService,
    PreoperativeDiagnosisService,
    SurgeryService,
    WardCabinService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
