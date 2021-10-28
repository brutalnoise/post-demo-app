import { ModuleWithProviders, NgModule } from "@angular/core";
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

@NgModule({
})

export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        ...services
      ],
    };
  }
}