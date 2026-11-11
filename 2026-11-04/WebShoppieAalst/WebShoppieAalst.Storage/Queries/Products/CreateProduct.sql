INSERT INTO storefront.products(title, description, price, stockcount)
VALUES (@title, @description, @price, @stockcount)
RETURNING ProductId