import { Component } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [NgxSpinnerService]
})
export class AppComponent {
  title = 'app';
}
