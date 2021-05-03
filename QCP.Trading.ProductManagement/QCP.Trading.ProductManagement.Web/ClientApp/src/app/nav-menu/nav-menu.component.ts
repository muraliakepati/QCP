import { Component, OnInit } from '@angular/core';
import { NgxPermissionsService } from 'ngx-permissions';
import * as constant from 'src/app/app.constants'

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  providers: [NgxPermissionsService]
})

export class NavMenuComponent {
  isExpanded = false;
  userRole: string;

  constructor( private permissionsService: NgxPermissionsService) {
  }

  ngOnInit(): void {
      this.userRole = constant.UserRole;
      this.permissionsService.loadPermissions([constant.UserRole]);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
