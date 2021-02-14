import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-shape-generator',
  templateUrl: './shape-generator.component.html',
  styleUrls: ['./shape-generator.component.css']
})

export class ShapeGeneratorComponent {
  errorMessage: SafeHtml = '';
  content: SafeHtml;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sanitizer: DomSanitizer) { }

  valuechange(newValue: any) {
    this.http.get<ApiResult>(this.baseUrl + 'shapegenerator?query=' + newValue).subscribe(result => {
      if (result.success) {
        this.content = this.sanitizer.bypassSecurityTrustHtml(result.value);
        this.errorMessage = '';
      }
      else {
        this.content = '';
        this.errorMessage = this.sanitizer.bypassSecurityTrustHtml(result.value);
      }

    }, error => {
      this.errorMessage = 'An error occurred: ' + error;
    });
  }
}

interface ApiResult {
  success: boolean;
  value: string;
}
