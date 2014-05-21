function s(a){return (a[0]>0)?((a[1]>0)?1:3):((a[1]<0)?2:0)}
function d(a){return a[0]>0?(a[1]>0?1:3):(a[1]>0?0:2)}
console.log(d([-1,-1]))
//(a[0]<0?0:3)