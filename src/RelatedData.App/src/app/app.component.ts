import { Component } from '@angular/core';
import { CategoryService, ProductService } from '@api';
import { combineLatest, map, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  readonly vm$ = this._productService.get()
  .pipe(
    switchMap(products => {
      const observables = products.map(product => this._categoryService.getById({ categoryId: product.categoryId }).pipe(
        map(category => {
          return {
            ...product,
            ...{categoryName: category.name}
          }
        })
      ));
      return combineLatest(observables);
    }),

    map(productsWithCategoryName => ({ productsWithCategoryName }))
  )

  constructor(
    private readonly _productService: ProductService,
    private readonly _categoryService: CategoryService
  ) { }
}
