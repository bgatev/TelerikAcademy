function a(b){
    i=c=e=1

    for(;i<=2*b;i++) i<=b?e=c*=i:e*=i

    return e/(b*c+c)/c/2
}

function b(n) {
    if (n == 0) return 1
    else return (4 * n - 2) * b(n - 1) / (n + 1)
}

//console.log(a(0))
//console.log(a(1))
//console.log(a(2))
//console.log(a(3))
//console.log(a(4))
//console.log(a(5))
//console.log(a(6))
console.log(y(7))
//console.log(a(8))
//console.log(a(9))
//console.log(a(10))
//console.log(a(11))
//console.log(2*b(12))


