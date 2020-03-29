CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 0
        DO INSTEAD
        DELETE
    FROM
        bench.products_0
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 1
        DO INSTEAD
        DELETE
    FROM
        bench.products_1
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 1
        DO INSTEAD
        DELETE
    FROM
        bench.products_1
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 2
        DO INSTEAD
        DELETE
    FROM
        bench.products_2
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 3
        DO INSTEAD
        DELETE
    FROM
        bench.products_3
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 4
        DO INSTEAD
        DELETE
    FROM
        bench.products_4
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 5
        DO INSTEAD
        DELETE
    FROM
        bench.products_5
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 6
        DO INSTEAD
        DELETE
    FROM
        bench.products_6
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 7
        DO INSTEAD
        DELETE
    FROM
        bench.products_7
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 8
        DO INSTEAD
        DELETE
    FROM
        bench.products_8
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_delete_to_products_0 AS ON DELETE TO bench.products
WHERE
    OLD.id % 10 = 9
        DO INSTEAD
        DELETE
    FROM
        bench.products_9
    WHERE
        id = OLD.id;

