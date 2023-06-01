import { Component, HostListener } from "@angular/core";
import { invoke } from "@tauri-apps/api/tauri";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  
  @HostListener('document:DOMContentLoaded', ['$event'])
  onDomContentLoaded(event: Event) {
    setTimeout(() => invoke('close_splashscreen'), 2000);
  }
}
