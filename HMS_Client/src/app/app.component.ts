import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrConfig, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HMS_Client';
  public loaderMessage: string = "loading test";

  public hideNav: boolean = false;

  constructor(private router: Router, private toastr: ToastrService) {
    // router.events.subscribe((url: any) => {
    // if (router.url == '/sign-in' || router.url == '/sign-up') {
    // this.hideNav = true;
    // }
    // });
  }

  ngOnInit() {
    // Custom toastr configuration
    const toastrConfig: Partial<ToastrConfig> = {
      positionClass: 'toast-top-right', // Adjust the position
      closeButton: true, // Show a close button
      progressBar: true, // Show a progress bar
      progressAnimation: 'increasing', // Progress animation style
      timeOut: 3000, // Display duration in milliseconds
    };

    this.toastr.show('Your message', 'Title', toastrConfig);
  }
}
