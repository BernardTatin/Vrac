;; =================================================
;; fact.lisp
;; =================================================

(defun factorial-1 (n)
  (if (= n 0)
    1
    (* n (factorial-1 (- n 1))) ) )

(defun factorial-2 (n)
  (labels ((ifact (k acc)
                    (if (= 0 k)
                      acc
                      (ifact (- k 1) (* k acc)))))
    (ifact n 1)))


(defun show-fact (the-fact n)
  (when (>= n 0)
    (format t "~A! = ~A~%" n (funcall the-fact n))
    (show-fact the-fact (- n 1))))

(show-fact #'factorial-2 120)
(show-fact #'factorial-1 120)
