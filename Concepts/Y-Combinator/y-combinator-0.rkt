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

(define almost-factorial
    (lambda (f)
      (lambda (n)
        (if (= n 0)
            1
            (* n (f (- n 1)))))))

;; return 20, not 120
(display-test "almost-factorial Id:" ((almost-factorial Id) 5))
