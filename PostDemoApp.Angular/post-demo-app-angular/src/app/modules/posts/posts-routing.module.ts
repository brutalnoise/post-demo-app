import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { PostListComponent } from "./components/list/post-list.component";

const routes = [
    {
        path: 'list',
        component: PostListComponent,
        data: { title: 'Posts List' }
      },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class PostsRoutingModule {}