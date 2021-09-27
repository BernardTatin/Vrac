;; #lang racket

(define display-test
    (lambda (name value)
        (display name)
        (display ": ")
        (display value)
        (newline)))

(define Id
    (lambda (x)
        x))

;; we start from a recursive function,
;; not tail recursive, which is  an explicitly recursive definition,
;; where the name of the function (factorial) is used to express recursivity
;; here is this factorial function:
(define factorial
    (lambda (n)
      (if (= n 0)
          1
          (* n (factorial (- n 1))))))

;; we want a function  which eliminate explicit recursion:
(define almost-factorial
    (lambda (f)
      (lambda (n)
        (if (= n 0)
            1
            (* n (f (- n 1)))))))

(define factorial0
    (lambda(n)
        ((almost-factorial Id) n)))

;; it doesn't work as expected:
(display-test "factorial0 0: " (factorial0 0))
(display-test "factorial0 1: " (factorial0 1))
(display-test "factorial0 5: " (factorial0 5))

(define factorial1
    (lambda(n)
        ((almost-factorial factorial0) n)))

;; it doesn't work as expected, even it's better
(display-test "factorial1 0: " (factorial1 0))
(display-test "factorial1 1: " (factorial1 1))
(display-test "factorial1 5: " (factorial1 5))

(define lazyY
    (lambda (f)
      (f (lazyY f))))

(define almost-factorial
    (lambda (f)
      (lambda (n)
        (if (= n 0)
            1
            (* n (f (- n 1)))))))

;; (define factorial (lazyY almost-factorial))

;; it doesn't work with many Schem emplementations,
;; only for lazy Scheme.
;; chezschem enters in an infinite loop
;; (display-test "factorial 0: " (factorial 0))
;; (display-test "factorial 1: " (factorial 1))
;; (display-test "factorial 5: " (factorial 5))

  (define Y 
    (lambda (f)
      ((lambda (x) (x x))
       (lambda (x) (f (lambda (y) ((x x) y)))))))

(define factorial (Y almost-factorial))
(display-test "factorial 0: " (factorial 0))
(display-test "factorial 1: " (factorial 1))
(display-test "factorial 5: " (factorial 5))