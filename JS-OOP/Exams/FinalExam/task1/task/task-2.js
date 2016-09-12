/* globals module */

"use strict";
function solve() {
    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }

        add(product) {
            this.products.push(product);
            return this;
        }

        remove(product) {
            //todo:
            if (this.products.length === 0) {
                throw "Shoping cart is empty!"
            }

            for (let i = 0; i < this.products.length; i++) {
                if (this.products[i].name == product.name) {
                    this.products.splice(i, 1);
                    return this;
                }
            }

            throw "Product not found!";
        }

        showCost() {
            if (this.products.length === 0) {
                return 0;
            }

            var totalCost = 0;
            this.products.forEach(x => totalCost += x.price);

            return totalCost;
        }

        showProductTypes() {
            if (this.products.length === 0) {
                return [];
            }

            let productTypes = [];
            for (let product of this.products) {
                if (productTypes.indexOf(product.productType) < 0) {
                    productTypes.push(product.productType);
                }
            }
            return productTypes.sort((a, b) => a > b);
        }

        getInfo() {
            if (this.products.length === 0) {
                return {
                    products: [],
                    totalPrice: 0
                }
            }

            let product = {},
                products = [],
                totalPriceShoppingCart = 0;
            this.products.forEach(x => {
                totalPriceShoppingCart += x.price;
                if (!product[x.name]) {
                    product[x.name] = {
                        name: x.name,
                        quantity: 1,
                        totalPrice: x.price
                    };

                    products.push(product[x.name]);
                }
                else {
                    product[x.name].quantity += 1;
                    product[x.name].totalPrice += x.price
                }

            });
            console.log(products);
            return  {
                products,
                totalPrice: totalPriceShoppingCart
            };
        }
    }
    return {
        Product, ShoppingCart
    };
}

module.exports = solve;