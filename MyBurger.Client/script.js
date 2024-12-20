window.onload = GetMenus();

let cartindex = 0;
let cart = [];

let currentProduct = {
  productId:"",
  productName:"",
  productPrice:0
};

let currentMenu = {
  menuId:"",
  menuName:"",
  menuPrice:0
};

function sendNotification(title,message){
  const toastElement = new bootstrap.Toast(document.getElementById('confirmationToast'));
  const toastTitle =document.getElementById('notTitle');
  const toastMessage =document.getElementById('notMessage');
  toastTitle.innerHTML = title;
  toastMessage.innerHTML = message;
  toastElement.show();  
}

function cartLoad(){
  let totalprice=0;
  const cartMenu = document.getElementById('cartMenu');
  const cartProduct = document.getElementById('cartProduct');
  cartMenu.innerHTML = "";
  cartProduct.innerHTML = "";
  const cartCounterEl = document.getElementById('cart-counter');
  cartCounterEl.innerHTML="";
  cartCounterEl.innerHTML= cart.length;

  cart.forEach(OrderedMenu =>{
    let row="";
    if(OrderedMenu.menuId != "00000000-0000-0000-0000-000000000000")
    {
      totalprice += parseFloat(OrderedMenu.menu.menuPrice);
      row += `<div class="card">
            <div class="card-header">
            <h5 class="card-title">${OrderedMenu.menu.menuName}</h5>
            </div>
            <div class="card-body">
              <ul class="list-group list-group-flush">
              `;
      OrderedMenu.OrderedMenuProduct.forEach(OrderedMenuProduct=>{
        row +=`<li class="list-group-item cartProductName">${OrderedMenuProduct.product.productName}</li>
        <ol class="list-group list-group-numbered">`;

        OrderedMenuProduct.unorderedIngrediant.forEach(unorderedIngrediant=>{
          row +=`<li class="list-group-item">${unorderedIngrediant.unOrderedIngrediantName} İstemiyorum</li>`
        })

        row+=`</ol>`
      });

      row +=`</ul>
            </div>
            <div class="card-footer cart-footer">
            <h6 class="card-title cart-price">Menu Price : ${OrderedMenu.menu.menuPrice} TL</h6>
            <a href="#" class="btn btn-danger" onclick=removeCart(${cartindex})>Remove</a>
            </div>
            
          </div>
          <br>`;

    cartMenu.innerHTML+=row;

    }
    else
    {
      OrderedMenu.OrderedMenuProduct.forEach(OrderedMenuProduct=>{
        totalprice+=parseFloat(OrderedMenuProduct.product.productPrice);
        row += `<div class="card">
            <div class="card-header">
            <h5 class="card-title">${OrderedMenuProduct.product.productName}</h5>
            </div>`;

            if(OrderedMenuProduct.unorderedIngrediant.length>0)
            {
              row+=`<div class="card-body">
                <ol class="list-group list-group-numbered"">`;
                
                  OrderedMenuProduct.unorderedIngrediant.forEach(unorderedIngrediant=>{
                    row +=`<li class="list-group-item">${unorderedIngrediant.unOrderedIngrediantName} İstemiyorum</li>`
                  });
              
              row+=`</ol>
            </div>`;
              
            }

        row +=`<div class="card-footer cart-footer">
            <h6 class="card-title cart-price">Product Price : ${OrderedMenuProduct.product.productPrice} TL</h6>
            <a href="#" class="btn btn-danger" onclick=removeCart(${cartindex})>Remove</a>
            </div>
            
            </div>
            <br>`;

        cartProduct.innerHTML+=row;

        // cartProduct.innerHTML += `<br><br><br>`+ OrderedMenuProduct.product.productName;
        // cartProduct.innerHTML += `<br>`+ OrderedMenuProduct.product.productId;
        // cartProduct.innerHTML += `<br>`+ OrderedMenuProduct.product.productPrice;
      });
    }

    cartindex++;
  })
  const cartPriceEl=document.getElementById('cart-price');
  cartPriceEl.innerHTML="Total Price : "+ totalprice.toFixed(2);
  cartindex=0;
}

const cartEl = document.getElementById("cart");

function removeCart(cartindex){
  cart.splice(cartindex,1);
  cartLoad();
  sendNotification("Ürün Çıkarma Başarılı","1 ürün sepetinizden çıkarıldı");
}


function cartProduct() {
    let unorderedIngrediant=[];
    const ingrediantBox = document.getElementById("unOrderedIngrediantBox");
    const checkboxes = ingrediantBox.querySelectorAll('input[type="checkbox"]');

    checkboxes.forEach((checkbox) => {
      if (checkbox.checked) {
        unorderedIngrediant.push({
          unOrderedIngrediantId : checkbox.value,
          unOrderedIngrediantName: checkbox.getAttribute('data-ingrediant-name')
        });
      }
    });
    OrderedMenu = {
        menuId:"00000000-0000-0000-0000-000000000000",
        OrderedMenuProduct : []
    };
    OrderedMenu.OrderedMenuProduct.push({
        product:currentProduct,
        "unorderedIngrediant" : unorderedIngrediant
    })
    unorderedIngrediant=[];
    cart.push(OrderedMenu);
    cartLoad();
    sendNotification("İşlem Başarılı","1 ürün sepetinize eklendi");
}

function cartMenu(){
  let unorderedIngrediant=[];
  let OrderedMenu = {
    menu: currentMenu,
    OrderedMenuProduct : []
  };
  const menuBox = document.getElementById("unOrderedMenuBox");
  const productCard = menuBox.querySelectorAll('div.card-body');
  productCard.forEach((product)=>{
    const productId = product.getAttribute('data-product-id');
    const productName = product.getAttribute('data-product-name');
    const productPrice = product.getAttribute('data-product-price');
    const checkboxes = product.querySelectorAll('input[type=checkbox]');
    checkboxes.forEach((checkbox)=>{
      if(checkbox.checked)
      {
        unorderedIngrediant.push({
          unOrderedIngrediantId : checkbox.value,
          unOrderedIngrediantName: checkbox.getAttribute('data-ingrediant-name')
        });
      }
    });
     OrderedMenuProduct = {
      "product" : {
        "productId" : productId,
        "productName" : productName,
        "productPrice" : productPrice
      },
      "unorderedIngrediant" : unorderedIngrediant
     };
     unorderedIngrediant = [];
     OrderedMenu.OrderedMenuProduct.push(OrderedMenuProduct);
  });
  cart.push(OrderedMenu);
  cartLoad();
  sendNotification("İşlem başarılı","1 menü sepetinize eklendi");
}

function addProductToMenu(button) {
  const menubox = document.getElementById("productBoxInMenuAdd");
  menubox.innerHTML += `<button type="button" value="${button.id}" class="btn btn-primary" onclick="removeProductToMenu(this)">${button.innerText}</button>`;
}

function removeProductToMenu(button) {
  button.remove();
}

function addIngrediant() {
  const name = document.getElementById("IngrediantAddName");
  const description = document.getElementById("IngrediantAddDescription");
  const ingrediant = {
    Name: name.value,
    Description: description.value,
  };

  fetch("http://localhost:5226/api/Ingrediant/Create", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(ingrediant),
  });

  sendNotification("Malzeme Ekleme Başarılı","1 malzeme sisteme başarıyla eklendi");
}

async function loadIngrediantBox() {
  const ingrediantBox = document.getElementById("ingrediantBoxInProductAdd");
  ingrediantBox.innerHTML = "";

  const request = await fetch("http://localhost:5226/api/Ingrediant/GetAll");
  const response = await request.json();

  response.forEach((content) => {
    const row = `
        <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="${content.id}">
            <label class="form-check-label" for="${content.id}">
              ${content.name}
            </label>
          </div>`;
    ingrediantBox.innerHTML += row;
  });
}

async function loadUnOrderedIngrediantBox(id,name,description,price,imageUrl) {
  currentProduct = {
    productId:id,
    productName:name,
    productPrice:price
  };
  const ingrediantBox = document.getElementById("unOrderedIngrediantBox");
  const pName = document.getElementById("OrderProductName");
  const pDesc = document.getElementById("OrderProductDescription");
  const pPrice = document.getElementById("OrderProductPrice");
  const pImage = document.getElementById("OrderProductImage");
  pName.innerText = name;
  pDesc.innerHTML = description;
  pPrice.innerHTML = "Price : " + price + " ₺";
  pImage.src = `http://localhost:5226/productImages/${imageUrl}`;

  ingrediantBox.innerHTML = "";

  const request = await fetch(
    "http://localhost:5226/api/Product/GetProductsIngrediant",
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(id),
    }
  );

  const response = await request.json();

  response.forEach((content) => {
    const row = `
        <div class="form-check">
            <input class="form-check-input" type="checkbox" value="${content.id}" id="${content.id}" data-ingrediant-name="${content.name}">
            <label class="form-check-label" for="${content.id}">
              ${content.name}
            </label>
          </div>`;
    ingrediantBox.innerHTML += row;
  });
}

async function loadUnOrderedMenuBox(id,name,description,price,imageUrl) {
    currentMenu={
      menuId:id,
      menuName:name,
      menuPrice:price
    };
    const ingrediantBox = document.getElementById("unOrderedMenuBox");
    const pName = document.getElementById("OrderMenuName");
    const pDesc = document.getElementById("OrderMenuDescription");
    const pPrice = document.getElementById("OrderMenuPrice");
    const pImage = document.getElementById("OrderMenuImage");
    pName.innerText = name;
    pDesc.innerHTML = description;
    pPrice.innerHTML = "Price : " + price + " ₺";
    pImage.src = `http://localhost:5226/menuImages/${imageUrl}`;
  
    ingrediantBox.innerHTML = "";
  
    const request = await fetch(
      "http://localhost:5226/api/Menu/GetMenuProductsIngrediant",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(id),
      }
    );
  
    const response = await request.json();
  
    response.forEach((product) => {
        let ingredientHtml = '';
        
        product.ingrediantDTOs.forEach(ingrediant => {
          ingredientHtml += `
            <div class="form-check mt-2">
              <input class="form-check-input" type="checkbox" value="${ingrediant.id}" data-ingrediant-name="${ingrediant.name}">
              <label class="form-check-label" for="${ingrediant.id}">
                ${ingrediant.name}
              </label>
            </div>
          `;
        });
        const row = `
          <div class="card" style="width: 18rem;">
            <div class="card-body" data-product-id="${product.productId}" data-product-name="${product.productName}" data-product-price="${product.productPrice}">
              <h5 class="card-title">${product.productName}</h5>
              ${ingredientHtml}
            </div>
          </div>
        `;
        ingrediantBox.innerHTML += row;
      });
}


async function loadProductBox() {
  const productListBox = document.getElementById("productListBox");
  productListBox.innerHTML = "";

  const request = await fetch("http://localhost:5226/api/Product/GetAll");
  const response = await request.json();

  response.forEach((content) => {
    const row = `<button type="button" class="list-group-item list-group-item-action" id="${content.id}" onclick="addProductToMenu(this)">${content.name}</button></button>`;
    productListBox.innerHTML += row;
  });
}

let chechkedIds = [];
function prepareIngrementList() {
  chechkedIds = [];
  const ingrediantBox = document.getElementById("ingrediantBoxInProductAdd");
  const checkboxes = ingrediantBox.querySelectorAll('input[type="checkbox"]');

  checkboxes.forEach((checkbox) => {
    if (checkbox.checked) {
      chechkedIds.push(checkbox.id);
    }
  });
}

let selectedProductIds = [];
function prepareProductList() {
  selectedProductIds = [];
  const productBox = document.getElementById("productBoxInMenuAdd");
  const buttons = productBox.querySelectorAll('button[type="button"]');
  buttons.forEach((button) => {
    selectedProductIds.push(button.value);
  });
  changeMenuAddStatus();
}

function changeMenuAddStatus() {
  const saveButton = document.getElementById("MenuAddSaveButton");
  if (selectedProductIds.length > 0) {
    saveButton.disabled = false;
  } else {
    saveButton.disabled = true;
  }
}

async function createProduct() {
  const productName = document.getElementById("ProductAddName").value;
  const productDescription = document.getElementById(
    "ProductAddDescription"
  ).value;
  const productPrice = document.getElementById("ProductAddPrice").value;
  const ingrediantsIds = chechkedIds;
  const productImage = document.getElementById("ProductAddImage").files[0];

  // FormData oluştur
  let formData = new FormData();
  formData.append("Name", productName);
  formData.append("Description", productDescription);
  formData.append("Price", productPrice);
  ingrediantsIds.forEach((id) => {
    formData.append("IngrediantsId", id);
  });
  formData.append("ProductPic", productImage); // Dosya ekle


  // Fetch API ile POST isteği gönder
  try {
    const response = await fetch("http://localhost:5226/api/Product/Create", {
      method: "POST",
      body: formData,
    });

    if (response.ok) {
      console.log("Product added successfully");
    } else {
      console.error("Failed to add product:", response.status);
    }
  } catch (error) {
    console.error("Error:", error);
  }

  selectedProductIds = [];
  sendNotification("Ürün Ekleme Başarılı","1 ürün sisteme başarıyla eklendi");

}

async function createMenu() {
  const name = document.getElementById("MenuAddName").value;
  const description = document.getElementById("MenuAddDescription").value;
  const price = document.getElementById("MenuAddPrice").value;
  const productIds = selectedProductIds;
  const menuImage = document.getElementById("MenuAddImage").files[0];

  let formData = new FormData();
  formData.append("Name", name);
  formData.append("Description", description);
  formData.append("Price", price);
  productIds.forEach((id) => {
    formData.append("ProductIds", id);
  });
  formData.append("MenuPic", menuImage);

  const response = await fetch("http://localhost:5226/api/Menu/Create", {
    method: "POST",
    body: formData,
  });
  sendNotification("Menü Ekleme Başarılı","1 menü sisteme başarıyla eklendi");
}

async function GetMenus() {
  const request = await fetch("http://localhost:5226/api/Menu/GetAll");
  const response = await request.json();
  const mainPage = document.getElementById("mainPageMenu");
  mainPage.innerHTML = "";
  response.forEach((item) => {
    const row = `<div class="card" style="width: 18rem;">
        <img src="http://localhost:5226/menuImages/${item.imageUrl}" class="card-img-top" alt="...">
        <div class="card-body">
        <h5 class="card-title">${item.name}</h5>
        <p class="card-text">${item.description}</p>
        <div id="menu-card-price">
        <h5 class="card-title">${item.price.toFixed(2)} ₺</h5>
        <a href="#" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#orderMenu" onclick="loadUnOrderedMenuBox('${item.id}','${item.name}','${item.description}','${item.price.toFixed(2)}','${item.imageUrl}')">Add To Cart</a>
        <button type="button" class="btn-close" aria-label="Close" onclick="menuDelete('${item.id}')"></button>        
            </div>
            </div>
          </div>`;
    mainPage.innerHTML += row;
  });

  GetProducts();
}

async function GetProducts() {
  const request = await fetch("http://localhost:5226/api/Product/GetAll");
  const response = await request.json();
  const mainPage = document.getElementById("mainPageProduct");
  mainPage.innerHTML = "";
  response.forEach((item) => {
    const row = `<div class="card" style="width: 18rem;">
            <img src="http://localhost:5226/productImages/${item.imageUrl}" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title">${item.name}</h5>
              <p class="card-text">${item.description}</p>
              <div id="menu-card-price">
              <h5 class="card-title">${item.price.toFixed(2)} ₺</h5>
              <a href="#" class="btn btn-danger" data-bs-toggle="modal" value="${item.id}" data-bs-target="#orderProduct" onclick="loadUnOrderedIngrediantBox('${item.id}','${item.name}','${item.description}','${item.price.toFixed(2)}','${item.imageUrl}')">Add To Cart</a>
              <button type="button" class="btn-close" aria-label="Close" onclick="productDelete('${item.id}')"></button>        
            </div>
            </div>
          </div>`;
    mainPage.innerHTML += row;
  });
}

function menuDelete(id) {
  const result = confirm("Bu içeriği silmek istediğinizden emin misiniz?");
  if (result === true) {
    fetch("http://localhost:5226/api/Menu/Delete", {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(id),
    }).then(() => {
      GetMenus();
    });
  }
  sendNotification("Menü Silme Başarılı","1 menü sistemden başarıyla silindi");
}

function productDelete(id) {
  const result = confirm("Bu içeriği silmek istediğinizden emin misiniz?");
  if (result === true) {
    fetch("http://localhost:5226/api/Product/Delete", {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(id),
    }).then(() => {
      GetProducts();
    });
  }
  sendNotification("Ürün Silme Başarılı","1 ürün sistemden başarıyla silindi");
}

function previewProduct() {
  const productName = document.getElementById("PreviewProductName");
  productName.innerHTML = document.getElementById("ProductAddName").value;
  const productDescription = document.getElementById(
    "PreviewProductDescription"
  );
  productDescription.innerHTML = document.getElementById(
    "ProductAddDescription"
  ).value;
  const productPrice=document.getElementById('PreviewProductPrice');
  productPrice.innerHTML = document.getElementById('ProductAddPrice').value + " ₺"
}

function previewMenu() {
  const productName = document.getElementById("PreviewMenuName");
  productName.innerHTML = document.getElementById("MenuAddName").value;
  const productDescription = document.getElementById(
    "PreviewMenuDescription"
  );
  productDescription.innerHTML = document.getElementById(
    "MenuAddDescription"
  ).value;
}

document
  .getElementById("ProductAddImage")
  .addEventListener("change", function (event) {
    const file = event.target.files[0]; // İlk seçilen dosyayı al
    if (file) {
      const reader = new FileReader(); // FileReader oluştur

      // Dosya yüklendiğinde bu fonksiyon tetiklenecek
      reader.onload = function (e) {
        const imgElement = document.getElementById("PreviewProductImage"); // img etiketini seç
        imgElement.src = e.target.result; // img'nin src'sini dosyanın veri URL'si ile güncelle
      };

      reader.readAsDataURL(file); // Dosyayı veri URL'si olarak oku
    }
  });

  document
  .getElementById("MenuAddImage")
  .addEventListener("change", function (event) {
    const file = event.target.files[0]; // İlk seçilen dosyayı al
    if (file) {
      const reader = new FileReader(); // FileReader oluştur

      // Dosya yüklendiğinde bu fonksiyon tetiklenecek
      reader.onload = function (e) {
        const imgElement = document.getElementById("PreviewMenuImage"); // img etiketini seç
        imgElement.src = e.target.result; // img'nin src'sini dosyanın veri URL'si ile güncelle
      };

      reader.readAsDataURL(file); // Dosyayı veri URL'si olarak oku
    }
  });