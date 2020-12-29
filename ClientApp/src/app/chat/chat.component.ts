import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

import { Message } from '../interfaces';
import { ChatService } from '../services/chat.service';

@Component({
  selector: 'chat-app',
  templateUrl: './chat.component.html'
})

export class ChatComponent {

  public messages: Observable<Message[]>;
  nameControl = new FormControl('');
  textControl = new FormControl('');
  @ViewChild('text', {static: false}) text: ElementRef;

  constructor(http: HttpClient, protected chatService: ChatService) {
    this.GetInfo();
  }

  public GetInfo() {
    this.messages = this.chatService.GetMessage();
  }

  public SendMessage() {
    this.chatService.Add(this.nameControl.value, this.textControl.value);

    setTimeout(() => { this.GetInfo(); }, 300);

    this.textControl.setValue('');

    this.text.nativeElement.focus();
  }

}
