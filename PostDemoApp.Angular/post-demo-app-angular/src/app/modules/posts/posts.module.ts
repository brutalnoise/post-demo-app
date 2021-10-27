import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { PostListComponent } from "./components/list/post-list.component";
import { PostsRoutingModule } from "./posts-routing.module";
import { PostService } from "./services/post.service";


const components = [
  PostListComponent
];

const services = [
  PostService
];

const imports = [
  SharedModule,
  PostsRoutingModule
];

@NgModule({
  imports: [...imports],
  declarations: [...components],
  providers: [...services],
  exports: [...components]
})
export class PostsModule { }