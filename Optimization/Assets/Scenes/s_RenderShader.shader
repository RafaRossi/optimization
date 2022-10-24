void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    // Normalized pixel coordinates (from 0 to 1)
    vec2 uv = fragCoord/iResolution.xy;
    vec2 muv;
    if (iMouse.z > 0.) {
        muv = iMouse.xy/iResolution.xy;
    } else {
        muv = vec2(.5+.3*sin(iTime*.3),.5);
    }
  
    vec3 col = texture(iChannel0, uv).xyz;

    // CAS algorithm
    float max_g = col.y;
    float min_g = col.y;
    vec4 uvoff = vec4(1,0,1,-1)/iChannelResolution[0].xxyy;
    vec3 colw;
    vec3 col1 = texture(iChannel0, uv+uvoff.yw).xyz;
    max_g = max(max_g, col1.y);
    min_g = min(min_g, col1.y);
    colw = col1;
    col1 = texture(iChannel0, uv+uvoff.xy).xyz;
    max_g = max(max_g, col1.y);
    min_g = min(min_g, col1.y);
    colw += col1;
    col1 = texture(iChannel0, uv+uvoff.yz).xyz;
    max_g = max(max_g, col1.y);
    min_g = min(min_g, col1.y);
    colw += col1;
    col1 = texture(iChannel0, uv-uvoff.xy).xyz;
    max_g = max(max_g, col1.y);
    min_g = min(min_g, col1.y);
    colw += col1;
    float d_min_g = min_g;
    float d_max_g = 1.-max_g;
    float A;
    max_g = max(0., max_g);
    if (d_max_g < d_min_g) {
        A = d_max_g / max_g;
    } else {
        A = d_min_g / max_g;
    }
    A = sqrt(max(0., A));
    A *= mix(-.125, -.2, muv.y);
    vec3 col_out = (col + colw * A) / (1.+4.*A);
    if (uv.x > (muv.x-1./iResolution.x)) {
        if (uv.x > (muv.x+1./iResolution.x)) {
            // 'Control' texture
            col_out = texture(iChannel1, uv).xyz;
        } else {
            // Black line
            col_out = vec3(0);
        }
    }
    
    
    // Output to screen
    fragColor = vec4(col_out,1);
}
