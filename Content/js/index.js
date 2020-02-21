

$(document).ready(function () {
    var AddToprice = (price) => {
        var divide = (price + 100) / 5;
        return price + divide + price;
    }
    $("#selectsort").on("change",
        function(e) {
            var sort = $(this).children("option:selected").val();
          
            $.ajax({
                url: "https://localhost:44315/Products/LoadAllProduct",
                data: { sorted: sort },
                dataType: "json",
                success: function(data) {
                    $(".newpro").empty();
                    data.forEach(item => {
                        var htmlstring = ` <div class="col-lg-4 col-md-6">
                                <div class="single-product">
                                    <img class="img-fluid" style="height: 271px;" src="${item.Photos}" alt="">
                                    <div class="product-details">
                                        <h6>
                                            <h3>${item.ProductName}</h3>"          </h6>
                                        <div class="price">
                                            <h6>$${item.Price}</h6>
                                            <h6 class="l-through" style="color: red">$ ${AddToprice(item.Price)}</h6>
                                            <input type="hidden" value="@seven" />
                                        </div>
                                        <div class="prd-bottom">
                                            <span class="social-info carts" data.id="${item.Id}">
                                             <span class="ti-bag carts" data.id="${item.Id}"></span>
                                                <p class="hover-text carts" data.id="${item.Id}">add to cart</p>
                                            </span>
                                            <span class="social-info wishlist  " data.id="${item.Id}">
                                                <span class="lnr lnr-heart wishlist" data.id=${item.Id}"></span>
                                                <p class="hover-text wishlist" data.id="${item.Id}">Wishlist</p>
                                            </span>
                                            <span class="social-info compare" data.id="${item.Id}">
                                                <span class="lnr lnr-sync  compare" data.id="${item.Id}"></span>
                                                <p class="hover-text compare" data.id="${item.Id}">compare</p>
                                            </span>
                                            <span class="social-info viewmore" onclick=redirectAction(${item.Id
                            }) ><span>
                                                <span class="lnr lnr-move viewmore"></span><p class="hover-text viewmore">view more</p>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          `
                        $(".newpro").append(htmlstring);

                    })
                },
                error: function(e) {
                    console.log(e);
                }

            });

        });
    redirectAction = (id) => {
        window.location = "https://localhost:44315/Products/AllProduct/" + id;
    }

    $(".newpro").ready(
      
        function (e) {
            $.ajax({
                url: "https://localhost:44315/products/ProductsPage",
                data:"",
                dataType: "json",
                success: function (data) {
                    data.forEach(item => {
                        var htmlstring = ` <div class="col-lg-4 col-md-6">
                                <div class="single-product">
                                    <img class="img-fluid" style="height: 271px;" src="${item.Photos}" alt="">
                                    <div class="product-details">
                                        <h6>
                                            <h3>${item.ProductName}</h3>"          </h6>
                                        <div class="price">
                                            <h6>$${item.Price}</h6>
                                            <h6 class="l-through" style="color: red">$ ${AddToprice(item.Price)}</h6>
                                            <input type="hidden" value="@seven" />
                                        </div>
                                        <div class="prd-bottom">
                                            <span class="social-info carts" data.id="${item.Id}">
                                             <span class="ti-bag carts" data.id="${item.Id}"></span>
                                                <p class="hover-text carts" data.id="${item.Id}">add to cart</p>
                                            </span>
                                            <span class="social-info wishlist  " data.id="${item.Id}">
                                                <span class="lnr lnr-heart wishlist" data.id=${item.Id}"></span>
                                                <p class="hover-text wishlist" data.id="${item.Id}">Wishlist</p>
                                            </span>
                                            <span class="social-info compare" data.id="${item.Id}">
                                                <span class="lnr lnr-sync  compare" data.id="${item.Id}"></span>
                                                <p class="hover-text compare" data.id="${item.Id}">compare</p>
                                            </span>
                                            <span class="social-info viewmore" onclick=redirectAction(${item.Id}) ><span>
                                                <span class="lnr lnr-move viewmore"></span><p class="hover-text viewmore">view more</p>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          `
                        $(".newpro").append(htmlstring);

                    })
                },
                error: function (e) {
                    console.log(e);
                }

            });

        })
   
  

});
