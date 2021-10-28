import { CommonModule } from "@angular/common";
import { ModuleWithProviders, NgModule } from "@angular/core";
import { ButtonRectangleComponent } from "./components/common/button-rectangle/button-rectangle.component";
import { Configuration } from "./constants/configuration";
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
  CommonModule
]

const components = [
  ButtonRectangleComponent
]

@NgModule({
  imports: [...modules],
  declarations: [...components],
  exports: [
    ...modules,
  ...components
]
})

export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        ...modules,
        ...services
      ],
    };
  }
}