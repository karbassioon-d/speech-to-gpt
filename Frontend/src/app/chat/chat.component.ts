import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  query: string = '';
  response: string = '';

  constructor(private http: HttpClient) {}

  sendQuery() {
    if (this.query.trim() === '') {
      return;
    }

    const apiUrl = `http://localhost:5234/api/OpenAI/UseChatGPT?query=${encodeURIComponent(this.query)}`;

    this.http.get(apiUrl).subscribe((data: any) => {
      this.response = data.outputResult;
    });
  }
}
