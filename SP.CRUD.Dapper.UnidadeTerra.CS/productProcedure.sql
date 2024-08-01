CREATE PROCEDURE FilterProducts
    @p_name NVARCHAR(255) = NULL,
    @p_price_min FLOAT = NULL,
    @p_price_max FLOAT = NULL,
    @p_category NVARCHAR(255) = NULL
AS
BEGIN
    SELECT *
    FROM Product
    WHERE (Name LIKE '%' + @p_name + '%')
      AND (Price >= ISNULL(@p_price_min, Price))
      AND (Price <= ISNULL(@p_price_max, Price))
      AND (Category = @p_category);
END;