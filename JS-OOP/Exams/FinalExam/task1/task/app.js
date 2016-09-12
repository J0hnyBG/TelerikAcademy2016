/* globals require console*/

"use strict";



let { ShoppingCart, Product } = require("./task-2")();

let cart = new ShoppingCart();
cart.products = cart.products || [];
cart.products.push(new Product("Type 1", "Pr 1", 1));
cart.products.push(new Product("Type 1", "Pr 1", 2));
cart.products.push(new Product("Type 1", "Pr 1", 2));
cart.products.push(new Product("Type 1", "Pr 1", 2));
cart.products.push(new Product("Type 1", "Pr 1", 3));
cart.products.push(new Product("Type 1", "Pr 2", 5));
cart.products.push(new Product("Type 1", "Pr 2", 5));

let info = cart.getInfo();
console.log(info.products.length === 2);
console.log(info.products);
console.log(info.totalPrice === 20);
