import { CommonModule } from "@angular/common";
import { ModuleWithProviders, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ButtonRectangleComponent } from "./components/common/button-rectangle/button-rectangle.component";
import { Configuration } from "./constants/configuration";
import { SafeHtmlPipe } from "./pipes/safe-html.pipe";
import { BaseHttpService } from "./services/baseHttp.service";
import { CommentService } from "./services/comment.service";
import { PostService } from "./services/post.service";
import { UserService } from "./services/user.service";

const services = [
  Configuration,
  BaseHttpService,
  CommentService,
  PostService,
  UserService
]

const modules = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
]

const components = [
  ButtonRectangleComponent
]

const pipes = [
  SafeHtmlPipe
]

@NgModule({
  imports: [...modules],
  declarations: [
    ...components, 
    ...pipes
  ],
  exports: [
    ...modules,
  ...components,
  ...pipes
]
})

export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        ...modules,
        ...services,
        ...pipes
      ],
    };
  }
}