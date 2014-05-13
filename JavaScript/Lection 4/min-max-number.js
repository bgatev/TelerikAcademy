function MinMax(nums) {
    var min = Math.min.apply(null, nums),
        max = Math.max.apply(null, nums);

    console.log(min);
    console.log(max);
}

var numbers = [134, 3, 56, 1, -4, 2, -98, 4];
MinMax(numbers);