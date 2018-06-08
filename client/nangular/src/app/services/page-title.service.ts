import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';

// This is a thin wrapper around the Angular Title service.

@Injectable({
  providedIn: 'root',
})
export class PageTitleService {
  constructor(private titleService: Title) {}

  public updateTitle(pageName: string) {
    // Prefix all page names with the app name.
    this.titleService.setTitle(`nAngular: ${pageName}`);
  }
}
