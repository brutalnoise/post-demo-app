import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { PostDetailsComponent } from "./components/details/post-details.component";
import { PostListComponent } from "./components/list/post-list.component";

const routes = [
    {
        path: 'list',
        component: PostListComponent,
        data: { title: 'Posts List' }
    },
    {
        path: 'details/:id',
        component: PostDetailsComponent,
        data: { title: 'Post Details' },
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PostsRoutingModule { }